using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.ViewModels
{
    public class MainViewModel : BindableBase, INotifyPropertyChanged
    {
        private readonly DataContext _dbContext;
        public MainViewModel()
        {
            _dbContext = new DataContext();
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
            _dbContext.FilmSet.Load();

            ReloadFilms();
        }

        private void ReloadFilms()
        {
            var items = _dbContext.FilmSet.Local.ToList();
            var result = items;

            if (IsSorted)
            {
                if (IsByTitle)
                {
                    result = items.OrderBy(x => x.Title).ToList();
                }
                else if (IsByDirector)
                {
                    result = items.OrderBy(x => x.Director).ToList();
                }
                else if (IsByWriter)
                {
                    result = items.OrderBy(x => x.Writer).ToList();
                }
                else if (IsByGenre)
                {
                    result = items.OrderBy(x => x.Genre).ToList();
                }
                else if (IsByYear)
                {
                    result = items.OrderBy(x => x.Year).ToList();
                }
                else
                {
                    result = items.OrderBy(x => x.Id).ToList();
                }
            }

            Films.Clear();
            result.ForEach(x =>
            {
                Films.Add(x);
            });
        }

        public ObservableCollection<Film> Films { get; set; } = new ObservableCollection<Film>();

        private bool _isSorted;

        public bool IsSorted
        {
            get => _isSorted;
            set
            {
                SetProperty(ref _isSorted, value);
                ReloadFilms();
            }
        }

        private bool _isByTitle = true;

        public bool IsByTitle
        {
            get => _isByTitle;
            set
            {
                SetProperty(ref _isByTitle, value);
                ReloadFilms();
            }
        }

        private bool _isByDirector;

        public bool IsByDirector
        {
            get => _isByDirector;
            set
            {
                SetProperty(ref _isByDirector, value);
                ReloadFilms();
            }
        }

        private bool _isByWriter;

        public bool IsByWriter
        {
            get => _isByWriter;
            set
            {
                SetProperty(ref _isByWriter, value);
                ReloadFilms();
            }
        }

        private bool _isByGenre;

        public bool IsByGenre
        {
            get => _isByGenre;
            set
            {
                SetProperty(ref _isByGenre, value);
                ReloadFilms();
            }
        }

        private bool _isByYear;

        public bool IsByYear
        {
            get => _isByYear;
            set
            {
                SetProperty(ref _isByYear, value);
                ReloadFilms();
            }
        }

        private string _newFilmTitle;
        public string NewFilmTitle
        {
            get => _newFilmTitle;
            set => SetProperty(ref _newFilmTitle, value);
        }

        private string _newFilmDirector;
        public string NewFilmDirector
        {
            get => _newFilmDirector;
            set => SetProperty(ref _newFilmDirector, value);
        }

        private string _newFilmWriter;
        public string NewFilmWriter
        {
            get => _newFilmWriter;
            set => SetProperty(ref _newFilmWriter, value);
        }

        private string _newFilmGenre;
        public string NewFilmGenre
        {
            get => _newFilmGenre;
            set => SetProperty(ref _newFilmGenre, value);
        }

        private int _newFilmYear;
        public int NewFilmYear
        {
            get => _newFilmYear;
            set => SetProperty(ref _newFilmYear, value);
        }

        public void SaveNewFilm()
        {
            _dbContext.Add(new Film
            {
                Title = NewFilmTitle,
                Director = NewFilmDirector,
                Writer = NewFilmWriter,
                Genre = NewFilmGenre,
                Year = NewFilmYear
            });
            _dbContext.SaveChanges();
            ReloadFilms();
            ClearNewFilm();
        }

        public void ClearNewFilm()
        {
            NewFilmTitle = "";
            NewFilmDirector = "";
            NewFilmWriter = "";
            NewFilmGenre = "";
            NewFilmYear = 0;
        }
    }
}
