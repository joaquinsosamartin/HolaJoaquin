export class GenericApiResponse<T> {
    result: T;
    statusCode: number;
    message: string;
    version: string;
    IsError: boolean;
    responseException: any;
}
