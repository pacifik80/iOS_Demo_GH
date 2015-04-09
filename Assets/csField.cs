using UnityEngine;
using System.Collections;

public class csField {
	int cntRows = 0;
	int cntCols = 0;

	cell[,] cells;


	public void InitField (int rows, int cols, Vector3[,] pos) {
		cntRows = rows;
		cntCols = cols;

		cells = new cell[rows, cols];

		for (int j = 0; j<rows; j++) {
			for (int i = 0; i < cols; i++) {

				cell c = new cell();

				c.position = pos[j,i];
				c.attachedBall = null;

				cells[j,i] = c;


			}
		}
	}
}

public class cell {
	public Vector3 position;
	public GameObject attachedBall;
}

