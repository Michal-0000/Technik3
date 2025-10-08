xxx = 0

def licz():
    global xxx
    xxx = 30
    print(f"{xxx}")


def dane(*args):
    for zmienna in args:
        print(f"Dane: {zmienna}")
        
def sumuj(*args):
    suma = 0
    for e in args:
        suma += e
    print(f"SUma wynosi: {suma}")

def przedstaw_sie(wiek, imie="Adam", nazwisko="Nowak"):
    print(f"Nazywam sie: {imie} {nazwisko} i mam {wiek} lat")


def main():
    #przedstaw_sie(20, "Jan", "Kowalski")
    # dane(3,4,5,6,7)
    # sumuj(3,4)
    licz()
    xxx = 10
    licz()
    print(f"{xxx}")
    licz()

if __name__ == "__main__":
    main()