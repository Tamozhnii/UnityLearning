int album = 52;
int imageZone = 3;
int entireRows = album / imageZone;
int remainingImages = album % imageZone;

Console.WriteLine($"Всего будет {entireRows} полных рядов, и еще останется {remainingImages} изображение(-ий)");