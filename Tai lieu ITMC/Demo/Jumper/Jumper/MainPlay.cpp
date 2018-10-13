#include<iostream>
#include"SFML/Graphics.hpp"
using namespace std;
using namespace sf;
int main() {
	RenderWindow window(VideoMode(400, 600), "Game Jumper");
	while (window.isOpen())
	{
		Event e;
		while (window.pollEvent(e))
		{

		}
		window.display();
	}
	system("pause");
	return 0;
}