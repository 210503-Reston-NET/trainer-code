//Encapsulation with IIFEs
let Outer = (() => {
    let count = 0;
    return function inner() {
        return count += 1;
    }
})();

//Encapsulation with regular functions
let Count = (
    () => {
        let count = 0;
        return () => {
            return count += 1;
        }
    }
);
let add = Count();
let addAgain = Count();