namespace Model
{
    public class ResponseModel<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
        public ResponseModel()
        {
            IsSuccess = true;
        }

        public ResponseModel(bool isSuccess, string error)
        {
            this.IsSuccess = isSuccess;
            this.ErrorMessage = error;
        }

        public ResponseModel(T data)
        {
            this.IsSuccess = true;
            this.Data = data;
        }
    }

}
