
namespace webApiBooks.models {
    internal class MaxlenghtAttribute : Attribute {
        public string ErrorMessageExtension;
        private int v;
        private string errorMessageExtension;

        public MaxlenghtAttribute(int v, string ErrorMessageExtension) {
            this.v = v;
            errorMessageExtension = ErrorMessageExtension;
        }
    }
}