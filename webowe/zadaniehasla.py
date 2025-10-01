import random as rd

def zapis(nazwa="hasla.txt", tryb="+wt"):
    # litery = [chr(rd.randint(97,112) in range(8)]
    #hasla = [(chr(rd.randint(97,112)) for j in range(8)).join() for i in range(1000)]
    
    print(hasla)
    try:
        with open(nazwa, tryb) as file:
            file.write(str(hasla))
    except FileNotFoundError:
        print(f"Plik {nazwa} nie znaleziony")
    except Exception as ex:
        print(f"błąd zapisu pliku")
    
    
    
    
    
    
def main():
    zapis("hasla.txt", "+wt")
    
if __name__ == "__main__":
    main()