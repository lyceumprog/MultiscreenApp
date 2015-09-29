using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MultiScreen
{
	[Activity (Label = "MultiScreen", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		List<string> teachersList = new List<string> (new string[] { "Фарида Ахметовна" , "Юрий Юрьевич" , "Артур Павлович" , "Денис Петрович"}); // Список учителей
		List<string> teachersLessonList = new List<string> (new string[] { "Биология" , "История" , "Математика" , "Английский"}); // Список уроков

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton); // Доступ к кнопке
			EditText newTeacherName = FindViewById<EditText> (Resource.Id.editText1); // Доступ к первому полю ввода
			EditText newTeacherLesson = FindViewById<EditText> (Resource.Id.editText2); // Доступ ко второму полю ввода
			ListView teachersListView = FindViewById<ListView> (Resource.Id.listView1); // Доступ к списку на интерфейсе

			teachersListView.Adapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleListItem1, teachersList); // Передача списка людей в список на интерфейсе
			
			button.Click += delegate { // обработка нажатия на кнопку
				teachersList.Add(newTeacherName.Text); // В список людей добавляется новый человек
				teachersLessonList.Add(newTeacherLesson.Text); // В список занятия добавляется новое занятие
				teachersListView.Adapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleListItem1, teachersList); // Передача списка людей в список на интерфейсе

				newTeacherName.Text = ""; // очищение первого поля ввода
			};

			teachersListView.ItemClick += (sender, e) => { // Обработка нажатия на элемент списка на интерфейсе
				Intent intent = new Intent(this, typeof(InformationActivity)); // Создание действия перехода
				intent.PutExtra("TeacherName", teachersList[e.Position]); // Передача имени выбранного человека в качестве параметра
				intent.PutExtra("TeacherLesson", teachersLessonList[e.Position]); // Передача урока, который преподает учитель, в качестве параметра

				StartActivity(intent); // Организуется переход на другое окно
			};
		}
	}
}


