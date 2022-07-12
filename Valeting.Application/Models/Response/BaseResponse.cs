namespace Valeting.Application.Models.Response
{
    public class BaseResponse<TSucess, TError> where TSucess : class where TError : class
    {
        public TSucess Result { get; private set; }
        public TError Error { get; private set; }
        public bool IsSucces => Result is not null;
        public bool IsError => !IsSucces;

        private BaseResponse(TSucess result)
        {
            Result = result;
        }

        private BaseResponse(TError error)
        {
            Error = error;
        }

        public static implicit operator BaseResponse<TSucess, TError>(TSucess result)
        {
            return new BaseResponse<TSucess, TError>(result);
        }

        public static implicit operator BaseResponse<TSucess, TError>(TError error)
        {
            return new BaseResponse<TSucess, TError>(error);
        }
    }
}
