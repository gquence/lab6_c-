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
					return ;
				_vector = new double[size];
				for (int i = 0; i < size; i++)
				{
					_vector[i] = value[i];
				}
				return ;
			}
			get
			{
				return (_vector);
			}
		}

		public double Mulitplication_of_elems()
		{
			double result;

			result = 1;

			foreach (double number in _vector)
				result *= number;
			return (result);
		}

		public double Sum_smoothed_values()
		{
			double	result;
			int		size;

			result = 0;
			size = _vector.GetLength(0) - 1;

			for (int i = 1; i < size; i++)
				result += (_vector[i - 1] + _vector[i] + _vector[i + 1]) / 3;
			return (result);
		}


		private double[] _vector;
	}

	class C_matrix
	{
		public double[,] Matrix
		{
			protected get
			{
				return (_matrix);
			}

			set
			{
				if (value.GetLength(0) != value.GetLength(1))
					return ;

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

				result = 1;
				for (int i = 0; i < _matrix.GetLength(0); i++)
				{
					for (int j = i + 1; j < _matrix.GetLength(0); j++)
					{
						double koef = _matrix[j, i] / _matrix[i, i];
						for (int z = i; z < _matrix.GetLength(1); z++)
							_matrix[j, z] -= koef * _matrix[i, z];
					}
					result *= _matrix[i, i];
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

		private double[,] _matrix;
	}

	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
	}
}
