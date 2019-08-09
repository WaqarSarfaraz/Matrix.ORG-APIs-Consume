using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixApiLogics.BusinessLogics
{
    public class BaseConfig : IDisposable
    {

        public string HomeServer { get { return "https://matrix.org/_matrix/client"; } }
        public string ApiLimitError { get { return "429"; } }
        public void Dispose()
        {
            this.Dispose();
        }
    }
}
