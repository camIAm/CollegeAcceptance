using System;

namespace ConsoleApplication
{
    public class Publisher
    {
        Object objectLock = new Object();
        public event EventHandler<AcceptanceLetter> RaiseCustomEvent;
        public event EventHandler<AcceptanceLetter> RaiseCustomEvents
        {
            add
            {
                lock (objectLock)
                {
                    RaiseCustomEvent += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    RaiseCustomEvent -= value;
                }
            }
        }
        public void DoSomething(string institute)    //Institute institute)
        {
            OnRaisedEvent(new AcceptanceLetter(institute)); // make canidate object
        }
        void OnRaisedEvent(AcceptanceLetter e)
        {
            EventHandler<AcceptanceLetter> handler = RaiseCustomEvent;

            if(handler != null)
            {
                e.Message += String.Format($" Date: {DateTime.Now}");
                handler(this,e);
            }
        }
    }
}