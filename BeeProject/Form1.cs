using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Max Herrington Final Exam Question 7
 * August 15, 2017
 * 
 * The idea was to determine the minimum distance between two cells containing 
 * bee maggots. The cells started at 1, and spiraled out in a clockwise fashion
 * with each new layer containing the same number of cells from the previous layer,
 * + 6.
 * 
 * Please see the DistanceCalc method below to see my final exam code comment
 * solution.
 * */

namespace BeeProject
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		/*a multidimensional array to store the coordinates for cells 1-70
		the first array has 70 elements (nubmer of cells), 
		the inner array has 3(an x, y, and z coord)
		*/
		int[,] coords = new int[70, 3]{
			//Cells
			{0,0,0 },//1
			{0,-1,1 },//2
			{-1,0,1 },//3
			{-1,1,0 },//4
			{0,1,-1 },//5
			{1,0,-1 },//6
			{1,-1,0 },//7
			{1,-2,1 },//8
			{0,-2,2 },//9
			{-1,-1,2 },//10
			{-2,0,2 },//11
			{-2,1,1 },//12
			{-2,2,0 },//13
			{-1,2,-1 },//14
			{0,2,-2 },//15
			{1,1,-2 },//16
			{2,0,-2 },//17
			{2,-1,-1 },//18
			{2,-2,0 },//19
			{2,-3,1 },//20
			{1,-3,2 },//21
			{0,-3,3 },//22
			{-1,-2,3 },//23
			{-2,-1,3 },//24
			{ -3,0,3},//25
			{-3,1,2 },//26
			{-3,2,1 },//27
			{-3,3,0 },//28
			{-2,3,-1 },//29
			{-1,3,-2 },//30
			{0,3,-3 },//31
			{1,2,-3 },//32
			{2,1,-3 },//33
			{3,0,-3 },//34
			{3,-1,-2 },//35
			{3,-2,-1 },//36
			{3,-3,0},//37
			{3,-4,1 },//38
			{2,-4,2 },//39
			{1,-4,3 },//40
			{0,-4,4 },//41
			{-1,-3,4 },//42
			{-2,-2,4 },//43
			{-3,-1,4 },//44
			{-4,0,4 },//45
			{-4,1,3 },//46
			{ -4,2,2},//47
			{-4,3,1 },//48
			{-4,4,0 },//49
			{-3,4,-1 },//50
			{2,4,-2 },//51
			{-1,4,-3 },//52
			{0,4,-4 },//53
			{1,3,-4 },//54
			{2,2,-4 },//55
			{3,1,-4 },//56
			{4,0,-4 },//57
			{4,-1,-3 },//58
			{4,-2,-2 },//59
			{4,-3,-1 },//60
			{4,-4,0 },//61
			{4,-5,1 },//62
			{3,-5,2 },//63
			{2,-5,3 },//64
			{1,-5,4 },//65
			{0,-5,5 },//66
			{-1,-4,5 },//67
			{-2,-3,5 },//68
			{-3,-2,5 },//69
			{-4,-1,5 },//70
		};

		
		//Please see the method below for my the code comment part of my Final
			//exam
		//method to calcualte the distance between two cells
		public void DistanceCalc()
		{
			/*obtain the x,y,z coords from the first cell selected
			by searching the first level of the array for the cell
			selected, and obtaining the 3 coords from the second level
			*/
			int x1 = coords[lstSelectFirstCell.SelectedIndex, 0];
			int y1 = coords[lstSelectFirstCell.SelectedIndex, 1];
			int z1 = coords[lstSelectFirstCell.SelectedIndex, 2];

			/*obtain the x,y,z coords from the second cell selected
			by searching the first level of the array for the cell
			selected, and obtaining the 3 coords from the second level
			*/
			int x2 = coords[lstSelectSecondCell.SelectedIndex, 0];
			int y2 = coords[lstSelectSecondCell.SelectedIndex, 1];
			int z2 = coords[lstSelectSecondCell.SelectedIndex, 2];

			//Take the difference from the coords 
			int xdis = x2 - x1;
			int ydis = y2 - y1;
			int zdis = z2 - z1;

			//find the absolute value of each difference
			int xabs = Math.Abs(xdis);
			int yabs = Math.Abs(ydis);
			int zabs = Math.Abs(zdis);

			/*find the maximum value of the abosolute values to determine the shortest
			distance between the cells
			*/
			int disMax = Math.Max(xabs, Math.Max(yabs, zabs));

			//display the result of the calculation to the user
			MessageBox.Show($"The shortest distance between cell {lstSelectFirstCell.SelectedIndex + 1} and cell {lstSelectSecondCell.SelectedIndex + 1} is {disMax}");
		}

		//When the user presses the calculate button
		private void btnCalculate_Click(object sender, EventArgs e)
		{
			//run the method to calculate the distance
			DistanceCalc();
		}

		//run the close method when the user clicks the exit button
		private void btnExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		//Reset the listboxes to the top option of 1
		private void btnReset_Click(object sender, EventArgs e)
		{
			lstSelectFirstCell.SelectedIndex = 0;
			lstSelectSecondCell.SelectedIndex = 0;
		}
	}
}
