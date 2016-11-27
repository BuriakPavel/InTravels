export class FormsErrors {
    property: string;
    errors: string[];
}
export interface IServiceResponce {
    ok: boolean;
    errors: FormsErrors;
}
export class ServiceResponce implements IServiceResponce {
    ok: boolean;
    errors: FormsErrors;

    constructor(status: boolean, errors: FormsErrors){
        this.ok = status;
        this.errors = errors;
    }
}