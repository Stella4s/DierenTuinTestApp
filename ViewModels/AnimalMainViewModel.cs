using DierenTuinTestApp.Models;
using DierenTuinTestApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Threading;

namespace DierenTuinTestApp.ViewModels
{
    public class AnimalMainViewModel : BaseViewModel
    {
        #region private properties
        private ObservableCollection<Animal> _AllAnimals;
        private AnimalTypes[] _AnimalTypesArr;
        private AnimalTypes _SelctFeedType;
        private AnimalTypes _SelctAddType;
        private DispatcherTimer dispatcherTimer;
        #endregion

        #region public properties
        public ObservableCollection<Animal> AllAnimals
        {
            get { return _AllAnimals; }
            set
            {
                _AllAnimals = value;
                OnPropertyChanged();
            }
        }
        public AnimalTypes[] AnimalTypesArr
        {
            get { return _AnimalTypesArr; }
            set
            {
                _AnimalTypesArr = value;
                OnPropertyChanged();
            }
        }
        public AnimalTypes SelctFeedType
        {
            get { return _SelctFeedType; }
            set
            {
                _SelctFeedType = value;
                OnPropertyChanged();
            }
        }
        public AnimalTypes SelctAddType
        {
            get { return _SelctAddType; }
            set
            {
                _SelctAddType = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public AnimalMainViewModel()
        {
            InitializeEnumerables();
            InitalizeTimer();
        }

        #region Methods
        #region Initalization & Helper methods
        private void InitializeEnumerables()
        {
            AllAnimals = new ObservableCollection<Animal>()
            {
                new Monkey(),
                new Elephant(),
                new Lion()
            };
            AnimalTypesArr = Enum.GetValues(typeof(AnimalTypes)).Cast<AnimalTypes>().ToArray();
        }
        private void InitalizeTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(Timer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(500);
            dispatcherTimer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach(Animal animal in AllAnimals.ToList())
            {
                animal.UseEnergy();
                if (HasAnimalStarved(animal))
                    AllAnimals.Remove(animal);
            }
        }
        private bool HasAnimalStarved(Animal animal)
        {
            if(animal != null)
            {
                if (animal.Energy <= 0)
                    return true;
            }
            return false;
        }
        #endregion

        #region ActionMethods
        public Animal GetAnimal(AnimalTypes animalType)
        {
            var ns = typeof(AnimalTypes).Namespace; //or your classes namespace if different
            var typeName = ns + "." + animalType.ToString();

            return (Animal)Activator.CreateInstance(Type.GetType(typeName));
        }

        public void AddAnimal()
        {
            AllAnimals.Add(GetAnimal(SelctAddType));
        }
        public void FeedAll()
        {
            foreach(Animal animal in AllAnimals)
            {
                animal.Eat();
            }
        }
        public void FeedGroup()
        {
            var animalgroup = AllAnimals.Where(animal => animal.Type == SelctFeedType);
            foreach (Animal animal in animalgroup)
            {
                animal.Eat();
            }
        }
        #endregion
        #region CanExecute Methods
        public bool IsAbleToFeed()
        {
            if (AllAnimals.Count != 0)
                return true;
            else
                return false;
        }
        public bool IsAbleToFeedGroup()
        {
            if (IsAbleToFeed())
            {
                if (AllAnimals.Where(ani => ani.Type == SelctFeedType).Any())
                    return true;
            }
            return false;
        }
        #endregion
        #endregion

        #region RelayCommands
        private RelayCommand _FeedAllCmd;
        public RelayCommand FeedAllCmd
        {
            get
            {
                if (_FeedAllCmd == null)
                {
                    _FeedAllCmd = new RelayCommand(FeedAll, IsAbleToFeed);
                }
                return _FeedAllCmd;
            }
        }
        private RelayCommand _FeedGroupCmd;
        public RelayCommand FeedGroupCmd
        {
            get
            {
                if (_FeedGroupCmd == null)
                {
                    _FeedGroupCmd = new RelayCommand(FeedGroup, IsAbleToFeedGroup);
                }
                return _FeedGroupCmd;
            }
        }
        private RelayCommand _AddAnimalCmd;
        public RelayCommand AddAnimalCmd
        {
            get
            {
                if (_AddAnimalCmd == null)
                {
                    _AddAnimalCmd = new RelayCommand(AddAnimal);
                }
                return _AddAnimalCmd;
            }
        }
        #endregion



    }
}
