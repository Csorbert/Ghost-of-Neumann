using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    public class EventListener
    {

        // Ide jönnek majd a listenerek

        public void QuickTimeAction()
        {
            Random rnd = new Random();
            double time = rnd.NextDouble()*(1.5-0.5)+0.5;
            Console.WriteLine(time);
        }

    }
}
