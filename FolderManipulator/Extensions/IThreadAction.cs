using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.Extensions
{
    public interface IThreadAction
    {
        void Prepare();
        void LoopStep();
        void Finish();
    }
}
