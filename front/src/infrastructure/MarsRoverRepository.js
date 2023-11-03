export class MarsRoverRepository {
  async sendCommands() {
    const data = [
      {
        "id": "10851021-d33f-42b0-b3e8-079337f521f9",
        "date": "2023-11-04",
        "temperatureC": 21,
        "temperatureF": 69,
        "summary": "Sweltering"
      },
      {
        "id": "e3195dbe-1608-41df-9cc0-eaeca292a4e2",
        "date": "2023-11-05",
        "temperatureC": 10,
        "temperatureF": 49,
        "summary": "Warm"
      },
      {
        "id": "971b31df-1d7b-4bcc-9f65-2a698ebda2d1",
        "date": "2023-11-06",
        "temperatureC": 20,
        "temperatureF": 67,
        "summary": "Freezing"
      },
      {
        "id": "a4bef070-5731-4c51-b623-29453c17d6b7",
        "date": "2023-11-07",
        "temperatureC": 6,
        "temperatureF": 42,
        "summary": "Cool"
      },
      {
        "id": "db2d86b2-991a-4f68-967f-3031c75b41ec",
        "date": "2023-11-08",
        "temperatureC": 12,
        "temperatureF": 53,
        "summary": "Chilly"
      }
    ];
    const headers = {
      'Content-Type': 'application/json',
      "Access-Control-Allow-Origin": "*"
  };
    const response = await fetch('http://localhost:5178/api/WeatherForecast/mock', {
      method: 'GET', 
      headers: headers});

      response.json().then(data => {
        console.log('response: ', data);
      });
      

    /*
    const movements = [{
        x: randomNumberBetween(0, 2),
        y: randomNumberBetween(0, 2),
        orientation: 'irrelevant',
        obstacle: false
      }]
      
    return Promise.resolve(movements)   ç
    */
  }
}

function randomNumberBetween(min, max) {
  return Math.floor(Math.random() * (max - min + 1) + min);
}