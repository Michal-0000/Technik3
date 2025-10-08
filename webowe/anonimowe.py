


def main():
    kw = lambda w: w**2
    
    
    print(f"Wartosc: {kw(10)}")
    
    liczby = [2,5,4,7,5,8]
    kwa = list(map(lambda w: w**2, liczby))
    print(f"Liczby: {kwa}")
    
    parz = list(filter(lambda x: x%2 == 0, liczby))
    print(f"Parzyste {parz}")
    
    owoce = ["jablko", "gruszka", "banan", "wisnia", "winogrono"]
    pos = sorted(owoce, key=lambda o: len(o), reverse=True)
    print(f"Owoce: {pos}")
    
    dane = [(2,4),(1,2),(5,1),(9,8)]
    poso = sorted(dane, key=lambda x: x[1])
    print(f"Daane: {poso}")
    
    
if __name__ == "__main__":
    main()