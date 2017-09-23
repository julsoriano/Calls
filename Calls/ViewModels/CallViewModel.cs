using Calls.Models;

namespace Calls.ViewModels
{
    public class CallViewModel
    {
        public Call Call { get; set; }
        public StatesDictionary States { get; set; }

        // The default constructor has no parameters. The default constructor  
        // is invoked in the processing of object initializers.  
        // You can test this by changing the access modifier from public to  
        // private. The declarations in Main that use object initializers will  
        // fail. See http://msdn.microsoft.com/en-us/library/vstudio/bb397680.aspx
        public CallViewModel() { }

        public CallViewModel(Call call)
        {
            Call = call;
            States = new StatesDictionary();
        }
    }
}