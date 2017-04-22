// XMLReplace.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <string>
#include <vector>

#include "Header.h"
using namespace std;



int main(int argc, char **argv)
{

	Replace(argc, argv);
	//Replace(argc, argv);
	return 0;

}


int Init(int argc, char **argv)
{

	//open and check both files
	if (argc != 3)      //pass three arguments to main,if not, print an error message
		throw runtime_error("EXE inputFile outputFile");
	ifstream infile(argv[1]);     //open transformation file
									//Note:argv[0] stores C-style characters  which is the name of the program that contains main() function,so the fisrt file is stored in argv[1]
	if (!infile)                  //check that open succeeded
		throw runtime_error("no input file");//you don't need to care about it now

	ofstream outfile(argv[2]);        //open file of text to transform,the second file,also the third parameters in argv
	if (!outfile)                     //check that open succeeded
		throw runtime_error("no output file");
	//ifstream infile;
	//infile.open("C:\\scip\\test.xml");

	//ofstream outfile;
	//outfile.open("C:\\scip\\out.xml");

	string string_main = "***";

	size_t pos = 0;

	int n = 0;
	int m = 0;
	//n = 0;

	string ns;
	string nstr;

	int count = 0;

	string string_sub;
	

	while (!infile.eof()) // To get you all the lines.
	{
		getline(infile, string_sub); // Saves the line in string_sub.
		//cout << string_sub << "\n"; // Prints our string_sub.

		cout << endl;
		cout << m << "..............................." << endl;
		m++;

		if (!string_sub.empty())
		{
			size_t result = string_sub.find(string_main); //check string_sub on the text file line by line, comparable to string_main

			if (result != string::npos)  // if found
			{
				count += 1;
				//break;
			}
		}

		while ((pos = string_sub.find(string_main, pos)) != std::string::npos) {
			n++;
			nstr = to_string(n); //  "TagName" +
			cout << n << "     " << nstr << endl;

			string_sub.replace(pos, string_main.length(), nstr);
			pos += ns.length();
		}
		outfile << string_sub;
		
	}
	infile.close();
	outfile.close();

    return 0;
}

/*
Replace
	map = "" field = "" tag = "" /
with 
	map="IP_ANALOGMAP" field="VAL" tag="ATCAI"/

*/

int Replace(int argc, char **argv)
{
	//open and check both files
	if (argc != 4)      //pass three arguments to main,if not, print an error message
		throw runtime_error("EXE inputFile outputFile");
	ifstream infile(argv[1]);     //open transformation file
								  //Note:argv[0] stores C-style characters  which is the name of the program that contains main() function,so the fisrt file is stored in argv[1]
	//cout << argv[1] << endl;
	if (!infile)                  //check that open succeeded
		throw runtime_error("no input file");//you don't need to care about it now

	//cout << argv[2] << endl;
	ifstream tagfile(argv[2]);        //open file of text to transform,the second file,also the third parameters in argv
	if (!tagfile)                     //check that open succeeded
		throw runtime_error("no tag file");
	
	//cin.get();
	//cout << argv[3] << endl;
	ofstream outfile(argv[3]);        //open file of text to transform,the second file,also the third parameters in argv
	if (!outfile)                     //check that open succeeded
		throw runtime_error("no output file");
	//ifstream infile;
	//infile.open("C:\\scip\\test.xml");

	//ofstream outfile;
	//outfile.open("C:\\scip\\out.xml");

	//tag="" field="" map=""
	string string_main = "tag=\"\" field=\"\" map=\"\"";
	//cout << string_main << endl;

	size_t pos = 0;

	int n = 0;
	int m = 0;
	//n = 0;

	string nstr;

	string string_sub;
	string tag_name;
	string tag_str;
	vector<string> taglist;

	//
	// set up the tag list from tagfile
	//

	cout << "tag list:" << endl;
	while (!tagfile.eof()) 
	{
		getline(tagfile, tag_name);
		taglist.push_back(tag_name);
		cout << tag_name << endl;
	}
	
	
	//cin.get();

	while (!infile.eof()) // To get you all the lines.
	{
		getline(infile, string_sub);

		n++;
		nstr = "defaultText=\"" + to_string(n) + "\"";

		while ((pos = string_sub.find(nstr, pos)) != std::string::npos) {
			//cout << nstr << endl;
			//cout << pos << endl;

			pos = string_sub.find(string_main, pos);
			if (pos == string::npos) break;
			//cout << pos << endl;

			tag_str = "tag=\"" + taglist[n - 1] + "\" field=\"VAL\" map=\"IP_ANALOGMAP\"";
			cout << nstr << "      " << tag_str << endl;

			string_sub.replace(pos, string_main.length(), tag_str);
			pos += tag_str.length();

			//cout << n << endl;

			n++;
			nstr = "defaultText=\"" + to_string(n) + "\"";
		}
				
		outfile << string_sub;

		//cin.get();
	}
	infile.close();
	outfile.close();

	return 0;
}




