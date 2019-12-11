import { environment } from 'src/environments/environment';

export class BaseService {

    protected baseUrl: string;

    constructor() {
        this.baseUrl = environment.holashopping.api;
    }
}
