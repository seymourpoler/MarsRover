export class MarsRoverRepository {
  async sendCommands() {
    
    const headers = {
      'Content-Type': 'application/json',
      "Access-Control-Allow-Origin": "*"
    };
    const response = await fetch('/api/MarsRovers', {
      method: 'GET', 
      headers: headers});
      const result = await response.json();
      return result;
  }

  async getRobotPosition(){
    const headers = {
      'Content-Type': 'application/json',
      "Access-Control-Allow-Origin": "*"
    };
    const response = await fetch('/api/MarsRovers', {
      method: 'POST', 
      headers: headers,
      body: JSON.stringify({"commands": "FF"})});
      const result = await response.json();
      return result;
  }
}
