


public class TemperatureRepository : DbContext
    {
    public async Task<IActionResult> GetTemperature(int id)
    {
        var http = new HttpClient();
        var url = string.Format("https://temperature-sensor-service.herokuapp.com/sensor/{0}", id);
        try
        {
            var response = await http.GetAsync(url);
        }catch (WebException ex)
        {
            using (WebResponse response = ex.Response)
            {
                HttpWebResponse httpResponse = (HttpWebResponse)response;
                Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                using (Stream data = response.GetResponseStream())
                using (var reader = new StreamReader(data))
                {
                    string text = reader.ReadToEnd();
                }
            }
        }
        var jsonString = await response.Content.ReadAsStringAsync();
        var sensorData = JsonSerializer.Deserialize<Sensor>(jsonString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return Ok(sensorData);
    }
}