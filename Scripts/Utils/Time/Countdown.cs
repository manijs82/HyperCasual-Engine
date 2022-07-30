namespace HyperCasual_Engine.Utils.Time
{
    public class Countdown
    {
        private readonly float time;
        private float currentTime;
        private bool started;

        public bool IsTicking => started;
        public float CurrentTime => currentTime;
        
        public Countdown(float time)
        {
            this.time = time;
        }

        public void Tick(float interval)
        {
            if (!started) return;
            
            currentTime -= interval;
            if(currentTime <= 0)
                Stop();
        }

        public void Start()
        {
            currentTime = time;
            started = true;
        }
        
        public void Resume()
        {
            started = true;
        }
        
        public void Stop()
        {
            started = false;
        }
    }
}