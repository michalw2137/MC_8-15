using System.Collections;
using Data;
using LogicLayer.Exceptions;
using InvalidDataException = LogicLayer.Exceptions.InvalidDataException;

namespace LogicLayer
{
    public class BallsManager
    {
        private readonly int _windowWidth;
        private readonly int _windowHeight;
        private readonly int _minRadius;
        private readonly int _maxRadius;
        private readonly ObjectStorage<Ball> _ballStorage = new();

        public BallsManager(int windowWidth, int windowHeight)
        {
            _windowHeight = windowHeight;
            _windowWidth = windowWidth;
            _minRadius = Math.Min(windowHeight, windowWidth) / 60; // imo nie bawic sie w min i max rad
            _maxRadius = Math.Max(windowWidth, windowHeight) / 30; // wszystkie takie same i elo

        }

        public int GetWindowWidth()
        {
            return _windowWidth;
        }

        public int GetWindowHeight()
        {
            return _windowHeight;
        }

        public int GetMinRadius()
        {
            return _minRadius;
        }

        public int GetMaxRadius()
        {
            return _maxRadius;
        }

        public void CreateBall(int ID, int x, int y, int xStep, int yStep) // to powinno byc prywatne i nietestowane
        {
            if (CheckForExistingID(ID)
               || (x < _minRadius || x > _windowWidth - _minRadius
                         || y < _minRadius || y > _windowHeight - _minRadius
                         || yStep > _windowHeight - _minRadius || yStep < ((-1) * _windowHeight + _minRadius)
                         || xStep > _windowWidth - _minRadius || xStep < ((-1) * _windowWidth + _minRadius)))
            {
                throw new InvalidDataException("The ball parameters entered are invalid");
            }
            else
            {
                Random rnd = new Random();
                Ball newBall = new Ball(ID, x, y, rnd.Next(_minRadius, _maxRadius), xStep, yStep);
                _ballStorage.AddBall(newBall);
            }
        }

        public void GenerateRandomBall()
        {
            Random rnd = new Random();
            int xrand = 0, yrand = 0;
            while (xrand == 0 && yrand == 0)
            {
                xrand = rnd.Next(-5, 5);
                yrand = rnd.Next(-5, 5);
            }


            CreateBall(AutoID()
                , rnd.Next(_maxRadius, _windowWidth - _maxRadius)
                , rnd.Next(_maxRadius, _windowHeight - _maxRadius)
                , xrand
                , yrand);
        }

        public void SummonBalls(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                GenerateRandomBall();
            }
        }

        public int AutoID()
        {
            int max = 0;
            foreach (Ball ball in GetAllBalls())
            {
                if (max < ball.GetID())
                {
                    max = ball.GetID();
                }
            }

            return max + 1;
        }

        public void DoTick()
        {
            //TODO: add ball radius to condition
            foreach (Ball ball in GetAllBalls())
            {
                if (ball.XPosition + ball.XStepSize + ball.Radius < ball.Radius * 2 || ball.XPosition + ball.XStepSize + ball.Radius > _windowWidth)
                {
                    ball.XStepSize = ball.XStepSize * (-1);
                }
                if (ball.YPosition + ball.YStepSize + ball.Radius < ball.Radius * 2 || ball.YPosition + ball.YStepSize + ball.Radius > _windowHeight)
                {
                    ball.YStepSize = ball.YStepSize * (-1);
                }
                ball.XPosition += ball.XPosition;
                ball.YPosition += ball.YPosition;
            }
        }

        public bool CheckForExistingID(int ID)
        {
            foreach (Ball obj in _ballStorage.GetAllBalls())
            {
                if (ID == obj.GetID())
                {
                    return true;
                }
            }

            return false;
        }

        public Ball GetBallByID(int ID)
        {
            foreach (Ball obj in _ballStorage.GetAllBalls())
            {
                if (ID == obj.GetID())
                {
                    return _ballStorage.GetAllBalls().ElementAt(ID);
                }
            }

            throw new InvalidDataException("The ball with the given ID is not in the list");
        }

        public void RemoveBallByID(int ID)
        {
            foreach (Ball obj in _ballStorage.GetAllBalls())
            {
                if (ID == obj.GetID())
                {
                    _ballStorage.RemoveBall(obj);
                    return;
                }
            }

            throw new InvalidDataException("The ball with the given ID is not in the list");
        }

        public List<Ball> GetAllBalls()
        {
            return _ballStorage.GetAllBalls();
        }

        public void ClearMap()
        {
            _ballStorage.ClearStorage();
        }
    }
}