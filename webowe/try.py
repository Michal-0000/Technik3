try:
    a = float(input("Podaj liczbę: "))
    b = float(input("Podaj drugą liczbę: "))
    
    wynik = a/b
    print(f"Wynikiem dzielenia {a} przez {b} jest {wynik}")
    
except ZeroDivisionError:
    print(f"Nie dzielimy przez zero...")
except ValueError:
    print("Podałeś złą wartość...")
except Exception as ex:
    print(f"Wystąpił nieoczekiwany błąd: {ex}")
finally:
    print("Zakonczenie dzialania")