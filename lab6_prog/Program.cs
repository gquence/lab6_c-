using System;

namespace lab6_prog
{
	class C_vector
	{
		public double[] Vector
		{
			set
			{
				int size = value.GetLength(0);
				if (size == 0)
					return;
				_vector = new double[size];
				for (int i = 0; i < size; i++)
				{
					_vector[i] = value[i];
				}
				return;
			}
			protected get => _vector;

		}

		public double Mulitplication_of_elems
		{
			get
			{
				double result;

				result = 1;

				foreach (double number in _vector)
					result *= number;
				return (result);
			}
		}

		public double Sum_smoothed_values()
		{
			double result;
			int size;

			result = 0;
			size = _vector.GetLength(0) - 1;

			for (int i = 1; i < size; i++)
				result += (_vector[i - 1] + _vector[i] + _vector[i + 1]) / 3;
			return (result);
		}

		public C_vector(double[] vector)
		{
			Vector = vector;
		}

		public bool Out_vector()
		{
			if (_vector.GetLength(0) < 2)
				return (false);
			foreach (double number in _vector)
				Console.Write(number + "\t\t");
			Console.Write("\n");
			return (true);
		}

		private double[] _vector;
	}

	class C_matrix
	{
		public double[,] Matrix
		{
			protected get => _matrix;

			set
			{
				if (value.GetLength(0) != value.GetLength(1))
					return;
				_matrix = new double[value.GetLength(0), value.GetLength(0)];
				for (int i = 0; i < value.GetLength(0); i++)
					for (int j = 0; j < value.GetLength(1); j++)
						_matrix[i, j] = value[i, j];
				return;
			}
		}

		public double Determinant
		{
			get
			{
				double result;
				double[,] matrix;

				result = 1;
				matrix = Matrix;
				for (int i = 0; i < matrix.GetLength(0); i++)
				{
					for (int j = i + 1; j < matrix.GetLength(0); j++)
					{
						double koef = matrix[j, i] / matrix[i, i];
						for (int z = i; z < matrix.GetLength(1); z++)
							matrix[j, z] -= koef * matrix[i, z];
					}
					result *= matrix[i, i];
				}
				return (result);
			}
		}

		public double Sum_main_diag()
		{
			double result;

			result = 0;

			for (int i = 0; i < _matrix.GetLength(0); i++)
				result += _matrix[i, i];
			return (result);
		}

		public double Sum_side_diagonal()
		{
			double result;

			result = 0;

			for (int i = 0; i < _matrix.GetLength(0); i++)
				result += _matrix[i, _matrix.GetLength(0) - 1 - i];
			return (result);
		}

		public bool Out_matrix() => Console_lib.Console_lib.Out_twodim_arr(_matrix);

		public C_matrix(double[,] matrix) => Matrix = matrix;

		private double[,] _matrix;
	}

	class Program
	{
		static void Out_inf()
		{
			Console.WriteLine("Работу выполнил студент М3О-235Б-17 Аншуков Михаил Андреевич");
			Console.ReadKey();
			Console.Clear();
		}

		static void Matrix_work()
		{
			C_matrix obj;
			double[,] matrix;
			int size;
			string msg;

			msg = "Введите размерность квадратной матрицы:";
			Console.WriteLine("Матрицы:");
			size = Console_lib.Console_lib.Enter_Int32(msg, 10, 2);
			matrix = new double[size, size];
			for (int i = 0; i < matrix.GetLength(0); i++)
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					msg = "Введите " + (i + 1) + " " + (j + 1) + "  элемент матрицы:";
					matrix[i, j] = Console_lib.Console_lib.Enter_double(msg, 100, -100);
				}
			obj = new C_matrix(matrix);
			Console.WriteLine("\nИтоговая матрица:");
			obj.Out_matrix();
			Console.Write("\nCумма элементов главной диагонали = " + obj.Sum_main_diag());
			Console.Write("\nCумма элементов побочной диагонали = " + obj.Sum_side_diagonal());
			Console.Write("\nОпределитель матрицы = " + obj.Determinant);
		}

		static void Vector_work()
		{
			C_vector obj;
			double[] vector;
			int size;
			string msg;

			msg = "Введите размер вектора:";
			Console.WriteLine("Векторы:");
			size = Console_lib.Console_lib.Enter_Int32(msg, 10, 2);
			vector = new double[size];
			for (int i = 0; i < vector.GetLength(0); i++)
			{
				msg = "Введите " + (i + 1) + " элемент вектора:";
				vector[i] = Console_lib.Console_lib.Enter_double(msg, 100, -100);
			}
			obj = new C_vector(vector);
			Console.WriteLine("\nИтоговый вектор:");
			obj.Out_vector();
			Console.WriteLine("\nПроизведение элементов вектора = " + obj.Mulitplication_of_elems);
			Console.WriteLine("Сумма сглаженных значений = " + obj.Sum_smoothed_values());
		}

		static void Main(string[] args)
		{
			Out_inf();
			string msg = "Хотите работать с матрицей или вектором?";
			string yes_msg = "матрица";
			string no_msg = "вектор";
			bool choice = Console_lib.Console_lib.Choice_of_two(msg, yes_msg, no_msg, 'm', 'v');
			if (choice)
				Matrix_work();
			else
				Vector_work();
			Console.ReadKey();
		}
	}
}
