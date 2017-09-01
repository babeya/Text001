using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{

    private enum States 
    {
        cell, 
        mirror, 
        sheets_0, 
        lock_0, 
        cell_mirror, 
        sheets_1, 
        lock_1, 
        freedom
    };

    private States myState;
    public Text text;

	// Use this for initialization
	void Start () 
    {
        myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (myState == States.cell) 
        {
            Cell();
        }
		else if (myState == States.sheets_0)
		{
			Sheets0();
		}
		else if (myState == States.lock_0)
		{
			Lock0();
		}
		else if (myState == States.mirror)
		{
			Mirror();
		}
		else if (myState == States.cell_mirror)
		{
			CellMirror();
		}
		else if (myState == States.sheets_1)
		{
			Sheets1();
		}
		else if (myState == States.lock_1)
		{
			Lock1();
		}
		else if (myState == States.freedom)
		{
			Freedom();
		}
	}

    void Cell() 
    {
        text.text = "You are on a prison cell, and you want to escape. There are " +
			"some dirty sheets on the bed, a mirror on the wall, and the door " +
			"is locked from the outside\n" +
			"Press S to view sheets, M to view mirror & L to view lock.";
		
        if (Input.GetKeyDown(KeyCode.S))
		{
			myState = States.sheets_0;
		}
		else if (Input.GetKeyDown(KeyCode.M))
		{
			myState = States.mirror;
		}
		else if (Input.GetKeyDown(KeyCode.L))
		{
			myState = States.lock_0;
		}
    }

    void Mirror() 
    {
        text.text = "What a beautifull mirror !!!\n"
            + "Press T to take the mirror, R to back.";

        if (Input.GetKeyDown(KeyCode.T)) 
        {
            myState = States.cell_mirror;
        }
		else if (Input.GetKeyDown(KeyCode.R))
		{
			myState = States.cell;
		}
    }

    void Sheets0()
    {
        text.text = "Those sheets are so dirty. "
            + "I hope i won't have to sleep here.\n"
            + "Press R to back";
		
        if (Input.GetKeyDown(KeyCode.R))
		{
			myState = States.cell;
		}
    }

    void Lock0() {
		text.text = "I need a key to opnen this.\n"
			+ "Press R to back";

		if (Input.GetKeyDown(KeyCode.R))
		{
			myState = States.cell;
		}
    }

    void CellMirror() {
        text.text = "The cell feel a bit diferrent.\n"
            + "Press S to view sheets, L to view lock.";

		if (Input.GetKeyDown(KeyCode.S))
		{
			myState = States.sheets_1;
		}
		else if (Input.GetKeyDown(KeyCode.L))
		{
			myState = States.lock_1;
		}
    }

    void Sheets1()
    {
        text.text = "Sheets are still as dirty as before.\n"
                + "Press R to back.";

        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell_mirror;

        }
    }

    void Lock1() {
        text.text = "The locks seems open !!!.\n"
            + "Press F to be free or R to back.";

		if (Input.GetKeyDown(KeyCode.F))
		{
            myState = States.freedom;

		}
        if (Input.GetKeyDown(KeyCode.R))
		{
			myState = States.cell_mirror;

		}
    }

    void Freedom() {
        text.text = "You are free !! Well done.";
    }
}
