def kalkulator(expr, a, b):
    match expr:
        case "dodaj":
            wynik = a+b
        case "odejmij":
            wynik = a-b
        case "pomnoz":
            wynik = a*b
        case "podziel":
            wynik = a/b
        case _:
            wynik = "Złe działanie..."
            
    return wynik

print(kalkulator("pomnoz", 3,4))