import { createMarsRoverPresenter } from './MarsRoverPresenter'
import { createMarsRoverView } from './MarsRoverView';
import { spyAllMethodsOf } from './../../Testing';
import { createHttp } from './../../Http';
import { HttpStatusCode } from './../../HttpStatusCode';


describe('Mars Rover Presenter', () => {
    let view, presenter, service, http;

    beforeEach(() => {
        view = createMarsRoverView();
        spyAllMethodsOf(view);
        http = createHttp();
        spyAllMethodsOf(http);
        presenter = createMarsRoverPresenter(view, http);
    });

    describe('when send command is requested', () => {

        it('hides messages', () => {
            const command = 'F'

            presenter.sendCommand(command);

            expect(view.cleanMessages).toHaveBeenCalled();
        });

        it('shows an error if cannot send the command', async () => {
            http.post = () => {
                return { statusCode: HttpStatusCode.internalServerError };
            };
            const command = 'F';

            await presenter.sendCommand(command);

            expect(view.showMessage).toHaveBeenCalledwith('something went wrong');
        });
    });
});
