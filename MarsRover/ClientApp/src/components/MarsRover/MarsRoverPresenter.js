import { createHttp } from "../../Http";

export function createMarsRoverPresenter(view, http) {
     var sendCommand = async function (command) {
         view.cleanMessages();

         const response = await http.post('api/v0/commands', command);
         if (response.statusCode === HttpStatusCode.internalServerError) {
             view.showMessage('something went wrong');
         }
    }

    return {
        sendCommand: sendCommand
    }
}
