using System;
using System.Collections;

namespace Q7
{
	

	public static class Program
	{
		public static void Main(String[] args)
		{
			Color color1 = new Color(12,13,14,221);
			Color color2 = new Color(22,24,25,15);

			Ball ball1 = new Ball(10, color1);
			Ball ball2 = new Ball(20, color2);

			ball2.Pop();

			for(int i=0; i<10; i++)
			{
				ball1.Throw();
				ball2.Throw();
			}

			Console.WriteLine($"The unpoped ball has been throwed {ball1.getThrown()} times");
			Console.WriteLine($"The poped ball has been throwed {ball2.getThrown()} times");
		}
		
	}

	public class Color
	{
		private int red;
		private int green;
		private int blue;
		public int alpha;

		public Color(int red, int green, int blue, int alpha=255)
		{
			this.red = red;
			this.green = green;
			this.blue = blue;
			this.alpha = alpha;
		}


		public int getRed()
		{
			return this.red;
		}

		public void setRed(int red)
		{
			this.red = red;
		}

		public int getGreen()
		{
			return this.green;
		}

		public void setGreen(int green)
		{
			this.green = green;
		}

		public int getBlue()
		{
			return this.blue;
		}

		public void setBlue(int blue)
		{
			this.blue = blue;
		}

		public int getAlpha()
		{
			return this.alpha;
		}

		public void setAlpha(int alpha)
		{
			this.alpha = alpha;
		}

		public int getGrey()
		{
			return (this.red + this.green + this.blue) / 3;
		}	
	}

	public class Ball
	{

		private int size;
		private Color color;
		private int nThrown;

		public Ball(int size, Color color)
		{
			this.size = size;
			this.color = color;
			this.nThrown = 0;
		}

		public void Pop()
		{
			this.size = 0;
		}

		public void Throw()
		{
			if (this.size > 0)
			{
				this.nThrown += 1;
			}
		}

		public int getThrown()
		{
			return this.nThrown;
		}






















	}
}