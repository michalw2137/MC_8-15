namespace Data
{
    public class ObjectStorage<T>
    {
        private List<T> _balls = new();
        public void AddBall(T obj)
        {
            _balls.Add(obj);
        }
        public List<T> GetAllBalls()
        {
            return _balls;
        }
        public void ClearStorage()
        {
            _balls.Clear();
        }
    }
}
