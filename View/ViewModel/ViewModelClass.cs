using Presentation.ViewModel.MVVMcore;
using Presentation.Model;
using System;
using System.Threading.Tasks;
using static Logic.ILogic;
using Logic;

namespace Presentation.ViewModel
{
    internal class ViewModelClass : BaseViewModel
    {
        private string _ballsAmount;
        public RelayCommand _summon { get; }
        public RelayCommand _clear { get; }
        public RelayCommand _pause { get; }
        public RelayCommand _resume { get; }

        public bool _summonFlag = true;
        public bool _clearFlag = false;
        public bool _resumeFlag = false;
        public bool _pauseFlag = false;

        public Window _Window { get; }

        public int _width { get; }
        public int _height { get; }

        public ViewModelClass()
        {
            _width = 1200;
            _height = 635;
            _ballsAmount = "";
            _summon = new RelayCommand(Summon, SummonProperties);
            _clear = new RelayCommand(Clear, ClearProperties);
            _resume = new RelayCommand(Resume, ResumeProperties);
            _pause = new RelayCommand(Pause, PauseProperties);
            _Window = new Window(_width, _height);
            SummonFlag = true;
            ClearFlag = false;
            ResumeFlag = false;
            PauseFlag = false;
        }

        public string BallsAmount
        {
            get => _ballsAmount;
            set
            {
                _ballsAmount = value;
                OnPropertyChanged();
            }
        }

        public bool SummonFlag
        {
            get => _summonFlag;

            set
            {
                _summonFlag = value;
                _summon.OnCanExecuteChanged();
            }
        }

        public bool ClearFlag
        {
            get => _clearFlag;

            set
            {
                _clearFlag = value;
                _clear.OnCanExecuteChanged();
            }
        }

        public bool ResumeFlag
        {
            get => _resumeFlag;

            set
            {
                _resumeFlag = value;
                _resume.OnCanExecuteChanged();
            }
        }

        public bool PauseFlag
        {
            get => _pauseFlag;

            set
            {
                _pauseFlag = value;
                _pause.OnCanExecuteChanged();
            }
        }

        public IBall2[]? GetBalls { get => _Window.GetBalls().ToArray(); }

        public void Summon()
        {
            try
            {
                int numberOfBalls = int.Parse(_ballsAmount);

                if (numberOfBalls < 1)
                {
                    throw new ArgumentException("Number of balls is less than 1");
                }

                _Window.CreateBalls(numberOfBalls);
                OnPropertyChanged("GetBalls");
                SummonFlag = false;
                ClearFlag = true;
                ResumeFlag = true;
                Tick();
            }
            catch (Exception)
            {
                BallsAmount = "";
            }
        }

        public void Clear()
        {
            BallsAmount = "";
            _Window.ClearBalls();
            OnPropertyChanged("GetBalls");
            SummonFlag = true;
            ClearFlag = false;
            ResumeFlag = false;
            PauseFlag = false;
        }

        public async void Tick()
        {
            while (true)
            {
                await Task.Delay(10);
                OnPropertyChanged("GetBalls");
            }
        }

        public void Resume()
        {
            PauseFlag = true;
            ResumeFlag = false;
            Tick();
        }

        public void Pause()
        {
            ResumeFlag = true;
            PauseFlag = false;
        }

        private bool SummonProperties()
        {
            return SummonFlag;
        }

        private bool ClearProperties()
        {
            return ClearFlag;
        }

        private bool ResumeProperties()
        {
            return ResumeFlag;
        }

        private bool PauseProperties()
        {
            return PauseFlag;
        }
    }
}