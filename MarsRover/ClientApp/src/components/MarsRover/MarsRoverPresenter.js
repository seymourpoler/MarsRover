import { HttpStatusCode } from './../../HttpStatusCode';


export function createMarsRoverPresenter(view, http) {
     var sendCommand = async function (command) {
         view.cleanMessages();

         // TODO: change url
         const response = await http.post('weatherforecast', { "value": command });
         console.log('log ' + JSON.stringify(response));

        if (response.statusCode === HttpStatusCode.internalServerError) {
             view.showMessage('something went wrong');
         }
     }

    return {
        sendCommand : sendCommand
    }
}
