#include <exception>
#include <iostream>
#include <string>

using namespace std;

class myException : public exception
{
private:
	int errorID;
	string errorMsg;

public:
	myException(int id, string msg)
	{
		setErrorID(id);
		setErrorMsg(msg);
	}

	int getErrorID()
	{
		return errorID;
	}

	string getErrorMsg()
	{
		return errorMsg;
	}

	void setErrorID(int id)
	{
		errorID = id;
	}

	void setErrorMsg(string msg)
	{
		errorMsg = msg;
	}

};