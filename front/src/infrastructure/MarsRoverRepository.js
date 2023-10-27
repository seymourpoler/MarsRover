export class MarsRoverRepository {
  sendCommands() {
    const movements = [{
        x: randomNumberBetween(0, 2),
        y: randomNumberBetween(0, 2),
        orientation: 'irrelevant',
        obstacle: false
      }]
      
    return Promise.resolve(movements)   
  }
}

function randomNumberBetween(min, max) {
  return Math.floor(Math.random() * (max - min + 1) + min);
}