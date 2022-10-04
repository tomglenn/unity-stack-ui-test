using System.Collections.Generic;
using System.Threading.Tasks;

namespace UI.Scripts
{
    public interface IScreen
    {
        public Task Init(IDictionary<string, object> data = null);
        public Task Enter();
        public Task Suspend();
        public Task Resume();
        public Task Exit();
    }
}