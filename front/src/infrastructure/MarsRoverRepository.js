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
}
