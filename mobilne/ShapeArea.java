public class ShapeArea {

    int area(int a)
    {
        return a * a;
    }
    int area(int a, int b)
    {
        return a * b;
    }
    double area(double a)
    {
        return 3.14 * a * a;
    }

    public static void main(String[] args) {
        ShapeArea shapeArea = new ShapeArea();
        System.out.println("Pole kwadratu: " + shapeArea.area(5));
        System.out.println("Pole prostokąta: " + shapeArea.area(5, 10));
        System.out.println("Pole kola: " + shapeArea.area(7.5));
    }
}
