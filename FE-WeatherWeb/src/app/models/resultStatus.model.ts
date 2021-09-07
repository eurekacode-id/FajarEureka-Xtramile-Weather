export class ResultStatus<TResult> {
	isSuccess: boolean;
	message: string;
	resultData: TResult;
    messageType: string;
}
