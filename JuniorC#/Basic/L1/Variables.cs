string nickname = "Terminator2000";
int age = 14;
uint coins = 10;
float progress = 10.5f;
decimal virtualMoney = 100.5m;
bool isVerification = true;
List<Stickers> stickers = new List<Stickers>() { Stickers.SubZero, Stickers.Kitana, Stickers.Goro };
var memoryBuffer;
Random rand = new Random();
char[,] map = new char[3, 5] {
  { '*', '*', ' ', ' ', ' ' },
  { ' ', '*', '*', '*', ' ' },
  { ' ', ' ', ' ', '*', '*' }
};
enum Stickers
{
  SubZero,
  Melina,
  Kitana,
  Goro,
  ShaoKahn,
  Raiden
}