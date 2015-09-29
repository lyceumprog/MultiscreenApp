
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MultiScreen
{
	[Activity (Label = "InformationActivity")]			
	public class InformationActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here

			SetContentView (Resource.Layout.InformationLayout);

			TextView teacherName = FindViewById<TextView> (Resource.Id.textView1); // Доступ к первому текстовому полю
			TextView teacherLesson = FindViewById<TextView> (Resource.Id.textView2); // Доступ ко второму текстовому полю

			teacherName.Text = Intent.GetStringExtra ("TeacherName"); // Принятие параметра и присваивание его тексту первого поля
			teacherLesson.Text = Intent.GetStringExtra ("TeacherLesson"); // Принятие параметра и присваивание его тексту второго поля
		}
	}
}

