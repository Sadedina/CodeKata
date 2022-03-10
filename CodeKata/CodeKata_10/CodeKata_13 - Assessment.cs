////#######################################################################################
//// WESTDEV LTD
//// CANDIDATE ASSESSMENT
//// C++ ASSESSMENT 'C'
////#######################################################################################
//// CANDIDATE NAME: 
//// DATE COMPLETED: 
////#######################################################################################



////#######################################################################################
//// QUESTION 1 : LINKED LISTS and POINTERS
////
//// Below you will find the start of two simple classes for a linked list, and a small 
//// fragment of code that creates and uses an instance of a linked list.
////
//// Write the code for the member functions that are not currently implemented.
//// If there are other functions or details that are required for 'correct' operation, 
//// add those too.
////#######################################################################################

//class CListNode
//{
//	public:
//	CListNode(int Value);

//	private:
//	CListNode* m_Next;
//	int m_Value;
//};

//class CLinkedList
//{
//	public:
//	CLinkedList();
//	CListNode* AddNode(int Value);
//	bool DeleteNode(CListNode* Node);
//};

//void main()
//{
//	CLinkedList MyList;
//	CListNode* NodeA = MyList.AddNode(1);
//	CListNode* NodeB = MyList.AddNode(2);
//	CListNode* NodeC = MyList.AddNode(3);

//	MyList.DeleteNode(NodeB);
//}

////#######################################################################################
//// QUESTION 2 : PARENTHESIS MATCHING
////
//// This is the skeleton of a function that takes a null-terminated string of text.
//// You are also given the index of a left or 'opening' parenthesis.
////
//// For example:
////
//// String = "When opening a door (for some reason (it could be any (real or imaginary) reason)) hold tight."
//// Index  = --------------------------------------^
////	
//// What the function should return is the index (from the beginning of the whole string)
//// of the corresponding (matching) right/closing parenthesis, or -1 if no matching 
//// parenthesis can be found. Write the code to complete this function.
////
//// Also, explain how you would protect against bad input, and how you would test this
//// function once it is written.
////
////#######################################################################################

//int FindMatchingParenthesis(char* String, int Index)
//{
//	int RightIndex;

//	return RightIndex;
//}

////#######################################################################################
//// QUESTION 3 : POINTERS
////
//// Consider the small fragment of code below that declares a variable of a structure
//// that is defined elsewhere, and a second variable that is deliberately initialised
//// as a pointer to the first. The 'memset' function is used to set a block of memory
//// to a given value, and requires a pointer to the data, the value to put in,
//// and the amount of memory (in bytes) to be set.
////
//// Is there a problem with any of the code here?
//// If so, how would you correct it?
////#######################################################################################

//{
//	MyStruct_t FirstInfo;
//	MyStruct_t* SecondInfo;
//	SecondInfo = &FirstInfo;

//	memset(SecondInfo, 0, sizeof(SecondInfo));
//}

////#######################################################################################
//// QUESTION 4 : COLOURS
////
//// Here is the skeleton for a function that takes the screen background colour
//// and a foreground colour to be used for drawing shapes on that background.
//// This function needs to work out an approximate colour to use for drawing those
//// items 'dimmed' so that they stand out less than items drawn in their normal colours.
////
//// Write the missing code to calculate a value for the dimmed colour, given the 'full on'
//// foreground colour and the colour of the window background on which the item is drawn.
////
////#######################################################################################

//COLORREF DimColour(COLORREF ForegroundColour, COLORREF BackgroundColour)
//{
//	int ForegroundRed = GetRValue(ForegroundColour);
//	int ForegroundGreen = GetGValue(ForegroundColour);
//	int ForegroundBlue = GetBValue(ForegroundColour);

//	// add implementation here to manipulate foreground colour elements
//	// to produce a colour that appears dimmed on the screen relative
//	// to something drawn in the original colour.



//	// Finally, compose the adjusted colour elements back into a Windows colour.
//	return RGB(ForegroundRed, ForegroundGreen, ForegroundBlue);
//}

////#######################################################################################
//// QUESTION 5 : OPERATORS and ORDER OF EVALUATION
////
//// Consider the small function below.
////
//// What value will be printed out?
////#######################################################################################

//# include <iostream>

//int main(int argc, char** argv)
//{
//	int x = 0;
//	int y = 0;

//	if (x++ && y++)
//	{
//		y += 2;
//	}

//	std::cout << x + y << std::endl;

//	return 0;
//}

////#######################################################################################
//// QUESTION 6 : EFFICIENCY
////
//// What things can you suggest to improve the efficiency of the code shown here?
////
////#######################################################################################

//void CountDigits(std::string Text)
//{
//	int Count = 0;
//	for (int Index = 0; Index < Text.length(); Index++)
//	{
//		std::string Digits("1234567890");
//if (Digits.find(Text[Index]) != std::string::npos)
//		{
//	Count++;
//}
//	}
//	return Count;
//}

////#######################################################################################
//// QUESTION 7 : IDENTIFYING PROBLEMS
////
//// This is a function that is intended to find the first occurrence of a given value
//// in an array of integers.
////
//// What can you find in the code shown here that could cause unexpected results or
//// unintended behaviour?
////
////#######################################################################################

//int FindFirstMatchingValue(int* List, int Count, int Value)
//{
//	int Result;

//	for (int Index = 1; Index < Count; Index++)
//	{
//		if (List[Index] = Value)
//		{
//			int Result = Index;
//		}
//	}

//	return Result;
//}

////#######################################################################################
//// QUESTION 8 : WHAT IS THE RESULT?
////
//// What value is output?
////
////#######################################################################################

//int Calculate(int* x, int& y, int z)
//{
//	(*x)++;
//	z = *x + y;
//	y += z;
//	return y;
//}

//int main()
//{
//	int a = 1;
//	int b = 2;
//	int c = 3;

//	int d = Calculate(&a, b, c);

//	std::cout << a + b + c + d << std::endl;

//	return 0;
//}

////#######################################################################################
//// QUESTION 9 : INHERITANCE  
////
//// What is the result of the code fragment below?
////
//// A) prints out the value SHAPE
//// B) prints out the value BOX
//// C) prints out an undefined value
//// D) won't compile
////
////#######################################################################################

//# include <iostream>

//struct Shape
//{
//	Shape* duplicate()
//	{
//		std::cout << "SHAPE" << std::endl;
//		return new Shape;
//	}
//	virtual ~Shape() { }
//};

//struct Box : public Shape
//{
//	virtual Box* duplicate()
//	{
//		std::cout << "BOX" << std::endl;
//		return new Box;
//	}
//};

//int main(int argc, char** argv)
//{
//	Shape* s1 = new Box;

//	Shape* s2 = s1->duplicate();

//	delete s1;
//	delete s2;
//	return 0;
//}

////#######################################################################################
//// QUESTION 10 : RECURSION
////
//// Below is a simple function that takes an ordered array of numbers, and returns the
//// index of the first entry in that array that has the given value. If the requested
//// number is not in the array, it returns -1 to indicate failure.
////
//// Write another function that uses recursion to perform the same task, and explain
//// why this is (or isn't) a better way than the first method.
////
////#######################################################################################

//int findItemInList(int* list, int count, int value)
//{
//	int found = -1;
//	for (int index = 0; index < count && found < 0; index++)
//	{
//		if (list[index] == value)
//		{
//			found = index;
//		}
//	}
//	return found;
//}

//int main()
//{
//	int numbers[] = { 2, 2, 3, 5, 6, 8, 14, 16, 22, 22, 30, 36 };
//	int howMany = 12;

//	return findItemInList(numbers, howMany, 22);
//}

////#######################################################################################
//// QUESTION 11 : GEOMETRY
////
//// Below is a partially completed class for a 'point', a position in 2D space.
//// 
//// Complete the 'Distance' function, which should return the distance between the
//// two points.
////
//// Also below is a function that takes two null-terminated lists of points,
//// and needs to return a point from each list where that pair of points are the
//// closest together from the two lists.
////
//// Complete the FindNearest function, including adding a way to pass back the results
//// to the caller.
////
////#######################################################################################

//typedef int TLength;

//class CPoint
//{
//	public:
//	TLength X() const {return m_X;}
//TLength Y() const {return m_Y;}

//	CPoint(TLength x = 0, TLength y = 0) { m_X = x; m_Y = y; }
//TLength Distance(const CPoint& point) const;

//private:
//	TLength m_X;
//TLength m_Y;
//};

//TLength CPoint::Distance(const CPoint& point) const
//{
//	// define the distance function
//}

//void FindNearest(CPoint* pointsA[], CPoint* pointsB[])
//{
//	// Find the nearest pair of points from the two null terminated arrays of points.
//}

////#######################################################################################
