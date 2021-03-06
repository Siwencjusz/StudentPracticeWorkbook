﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Workbook.BLL.DTOs;
using Workbook.BLL.Services.Serv;
using Workbook.BLL.Services.Serv.Workbook.BLL.Services.Serv;
using Workbook.DAL.Entities;

namespace Student.ViewModels
{
    public class StudentWorkbooksViewModel : BindableBase
    {
        private readonly WorkBookService _workBookService;
        private readonly BookNoteService _bookNoteService;

        public StudentWorkbooksViewModel(WorkBookService workBookService, BookNoteService bookNoteService)
        {
            _workBookService = workBookService;
            _bookNoteService = bookNoteService;

            WorkbooksList = new ObservableCollection<WorkbookDTO>(_workBookService.FindAll());
            NotesList = new ObservableCollection<BookNoteDTO>();

            AddNoteCommand = new DelegateCommand<object>(AddNote, (x) => true);
            RemoveNoteCommand = new DelegateCommand<object>(RemoveNote, (x) => true);
            SaveNoteCommand = new DelegateCommand<object>(SaveNote, (x) => true);
        }

        private void SaveNote(object obj)
        {
            if (SelectedBookNote.Id == Guid.Empty)
            {
                _bookNoteService.Add(_selectedBookNote);
            }
            else
            {
                _bookNoteService.Update(_selectedBookNote);
            }
        }

        private void RemoveNote(object obj)
        {
            _bookNoteService.Remove(_selectedBookNote);
            _selectedBookNote = null;
        }

        private void AddNote(object obj)
        {
            SelectedBookNote = new BookNoteDTO()
            {
                StartDate = DateTime.Now

            };
            SelectedBookNote.Workbook = SelectedWorkBook;
            NotesList.Add(_selectedBookNote);
        }

        public ObservableCollection<WorkbookDTO> WorkbooksList { get; set; }
        public ObservableCollection<BookNoteDTO> NotesList { get; set; }

        private WorkbookDTO _selectedWorkBook;
        public WorkbookDTO SelectedWorkBook
        {
            get { return _selectedWorkBook; }
            set
            {
                _selectedWorkBook = value;
                NotesList = new ObservableCollection<BookNoteDTO>(_selectedWorkBook.Noteses);
                OnPropertyChanged("SelectedWorkBook");
                OnPropertyChanged("NotesList");
            }
        }

        private BookNoteDTO _selectedBookNote;
        public BookNoteDTO SelectedBookNote
        {
            get { return _selectedBookNote; }
            set
            {
                _selectedBookNote = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddNoteCommand { get; }
        public ICommand RemoveNoteCommand { get; }
        public ICommand SaveNoteCommand { get; }




    }
}
