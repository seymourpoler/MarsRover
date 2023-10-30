import { HttpStatusCode } from './../../HttpStatusCode';


export function createMarsRoverPresenter(view, http) {
     var sendCommand = async function (command) {
         view.cleanMessages();

         const response = await http.post('command', command);

        if (response.statusCode === HttpStatusCode.internalServerError) {
             view.showMessage('something went wrong');
         }
    }

    return {
        sendCommand: sendCommand
    }
}
