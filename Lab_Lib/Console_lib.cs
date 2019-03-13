﻿using System;

namespace Console_lib
{
	public class Console_lib
	{
		public static bool Change_windowsize(Int32 targ_width, Int32 targ_height)
		{
			Int32 curr_w;
			Int32 curr_h;
			bool diff_w;
			bool diff_h;

			if (targ_height < _min_window_height)
				targ_height = _min_window_height;
			if (targ_width < _min_window_width)
				targ_width = _min_window_width;
			if (targ_height > _max_window_height)
				targ_height = _max_window_height;
			if (targ_width > _max_window_width)
				targ_width = _max_window_width;
			curr_h = Console.WindowHeight;
			curr_w = Console.WindowWidth;
			diff_h = false;
			diff_w = false;
			while ((diff_w = (curr_w != targ_width)) || (diff_h = (curr_h != targ_height)))
			{
				if (diff_w)
					curr_w = curr_w < targ_width ? curr_w + 1 : curr_w - 1;
				if (diff_h = (curr_h != targ_height))
					curr_h = curr_h < targ_height ? curr_h + 1 : curr_h - 1;
				Console.SetWindowSize(curr_w, curr_h);
			}
			return (true);
		}

		public static bool Choice_of_two(string msg, string yes_msg, string no_msg, char yes, char no)
		{
			int Origrow = Console.CursorTop;
			Console.Write(msg + " (" + yes + " - " + yes_msg + " / " + no + " - " + no_msg + ") ");

			while ((char.TryParse(Console.ReadLine(), out char ch)))
			{
				if (ch == no)
					return (false);
				if (ch == yes)
					return (true);
				for (int i = Console.CursorTop; i >= Origrow; i--)
					Clr_prevline(i);
				Console.Write(msg + " (" + yes + " / " + no + ") ");

			}
			return (false);
		}

		public static void Clr_prevline(Int32 CursorTop)//очистка предыдущей линии
		{
			char[] blank_line;

			blank_line = new char[Console.BufferWidth];

			if (CursorTop < 0)
				return;
			for (Int32 i = 0; i < blank_line.GetLength(0); i++)
				blank_line[i] = ' ';
			Console.SetCursorPosition(0, CursorTop);
			Console.Write(blank_line);
			Console.SetCursorPosition(0, CursorTop);
		}

		private static string HorizLine()
		{
			string s = "+";
			for (int i = 1; i <= Console.WindowWidth - 3; i++)
				s += "-";
			s += "+";
			return (s);
		}

		public static string Output_MiddleString(string inputString)// Формирование одной строки с центрированием
		{
			string s = "|";
			for (int i = 1; i <= (Console.WindowWidth - 3 - inputString.Length) / 2; i++)
				s += " ";
			s += inputString;
			for (int i = 1; i < Console.WindowWidth - 2 - ((Console.WindowWidth - 3 - inputString.Length) / 2) - inputString.Length; i++)
				s += " ";
			s += "|";
			return s;
		}

		public static void My_business_card
		(
		string taskDescription = "Какое-то задание",    // Описание задания
		string stugGroup = "Какая-то группа",          // Код группы
		string student = "Неизвестный студент")      // Студент
		{
			char[] delimiterChars = { '\t', '\n' }; // Разделители
			ConsoleColor currentForeColor = Console.ForegroundColor; // Текущий цвет букв
			ConsoleColor currentBackColor = Console.BackgroundColor; // Текущий цвет фона 
			Console.Clear();    // Очищаем консоль
			Console.BackgroundColor = ConsoleColor.Blue; // Задаем цвет фона
			Console.ForegroundColor = ConsoleColor.Yellow; // Задаем цвет букв
			Console.WriteLine(HorizLine()); // Верхняя горизонтальная линия
											// Разбиение "задания" на строки по разделителям.
			string[] rows = taskDescription.Split(delimiterChars);
			Console.WriteLine(Output_MiddleString("Задание"));
			foreach (string r in rows)
				Console.WriteLine(Output_MiddleString(r));//Строки задания
			Console.WriteLine(HorizLine()); // Горизонтальная линия
			Console.WriteLine(Output_MiddleString("Задание выполнил:"));
			Console.WriteLine(Output_MiddleString("Студент:" + student));
			Console.WriteLine(Output_MiddleString("Группа:" + stugGroup));
			Console.WriteLine(HorizLine());// Нижняя горизонтальная линия
										   // Востановление цветов консоли
			Console.BackgroundColor = currentBackColor;
			Console.ForegroundColor = currentForeColor;
			// Запоминием позицию курсора где закончили вывод визитки
			ConsolePositionX = Console.CursorLeft;
			ConsolePositionY = Console.CursorTop;
		}

		private	static	int		ConsolePositionX;
		private	static	int		ConsolePositionY;
		private	const	Int32	_max_window_width = 140;
		private	const	Int32	_max_window_height = 50;
		private	const	Int32	_min_window_width = 100;
		private	const	Int32	_min_window_height = 30;
		
	}
}
