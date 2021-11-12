


public class TemperatureRepository : DbContext
    {
    public async Task<IActionResult> GetTemperature(int id)
    {
        var http = new HttpClient();
        var url = string.Format("https://temperature-sensor-service.herokuapp.com/sensor/{0}", id);
        var response = await http.GetAsync(url);
        var jsonString = await response.Content.ReadAsStringAsync();
        var sensorData = JsonSerializer.Deserialize<Sensor>(jsonString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return Ok(sensorData);
    }
}