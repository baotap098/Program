#include<iostream>
#include"SFML/Graphics.hpp"
#include<ctime>
#include<cstdlib>
using namespace std;
using namespace sf;
#define heightW 650
#define widthW 400
struct point
{
	int x, y;
};
int main() {
	// Thiet lap kich thuoc cua so window
	RenderWindow app(VideoMode(widthW, heightW), "Jump", Style::Close);
	app.setFramerateLimit(60);
	// thiet lap be mac vat lieu
	Texture t1, t2, t3;
	t1.loadFromFile("img/bg.png"); // backgroud
	t2.loadFromFile("img/pl.png"); // player
	t3.loadFromFile("img/go.png"); // go

	Sprite bg(t1), pl(t2), go(t3);
	// hien kich thuoc cac doi tuong
	cout << "Player: " << pl.getGlobalBounds().height << ";" << pl.getGlobalBounds().width << endl;
	cout << "Backgroud: " << bg.getGlobalBounds().height << ";" << bg.getGlobalBounds().width << endl;
	cout << "Go: " << go.getGlobalBounds().height << ";" << go.getGlobalBounds().width << endl;

	// thay doi tam cua hinh
	go.setOrigin(0, go.getGlobalBounds().height);// doi tam ve goc trai-duoi
	go.setScale(0.25, 0.25);
	go.setPosition(0, go.getGlobalBounds().height);

	pl.setOrigin(pl.getGlobalBounds().width / 2, pl.getGlobalBounds().height);// doi tam ve giua-duoi, doi tam truoc khi scale
	pl.setScale(0.25, 0.25);
	// set vi tri cho pl
	point pPl;
	float dx = 0, dy = 0, h = 300;
	pPl.x = widthW / 2;
	pPl.y = pl.getGlobalBounds().height;
	pl.setPosition(pPl.x, pPl.y);


	point ps[10];
	srand(time(NULL));
	for (int i = 0; i < 10; ++i) {
		ps[i].x = rand() % 400;
		ps[i].y = 65 * i;
	}

	while (app.isOpen())
	{
		Event e;
		while (app.pollEvent(e))
		{
			if (e.type == Event::Closed)
				app.close();
		}
		app.draw(bg);
		// control pl
		if (Keyboard::isKeyPressed(Keyboard::Right)) {
			pPl.x += 4;
		}
		if (Keyboard::isKeyPressed(Keyboard::Left)) {
			pPl.x -= 5;
		}

		dy += 0.5;
		pPl.y += dy;
		if (pPl.y > heightW)
			dy = -15;
		if (pPl.y < h) {// cao hon tam man hinh game
			pPl.y = h;
			for (int i = 0; i < 10; ++i) {
				ps[i].y -= dy;// roi xuong
				if (ps[i].y > heightW) {
					ps[i].x = rand() % 400;
					ps[i].y = 0;
				}
			}
		}
		// bat va cham voi go
		for (int i = 0; i < 10; ++i) {
			if ((pPl.x > ps[i].x && pPl.x < ps[i].x + go.getGlobalBounds().width)
				&&
				(pPl.y > ps[i].y && pPl.y < ps[i].y + go.getGlobalBounds().height)
				&&
				dy > 0) { // khong cho nhay lien tuc
				dy = -15;
				cout << char(7);
			}
		}
		pl.setPosition(pPl.x, pPl.y);
		app.draw(pl);
		for (int i = 0; i < 10; ++i) {
			go.setPosition(ps[i].x, ps[i].y);
			app.draw(go);
		}
		app.display();
	}
	system("pause");
	return 0;
}

