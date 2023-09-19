// Jämför egenskaper i ett objekt med en array av objekt.
// Returnerar `true` om några matchande egenskaper hittades, annars `false`,
// och en meddelandesträng som innehåller den första matchande egenskapen om en matchning hittades.
export function compareObjectProperties(
  obj,
  arrayOfObjects,
  excludeProperties = []
) {
  const matchingProperties = []; // Lista för matchande egenskaper

  // Loopa igenom egenskaperna i objektet `obj`
  for (const property in obj) {
    if (obj.hasOwnProperty(property) && !excludeProperties.includes(property)) {
      // Loopa igenom objekten i `arrayOfObjects` och jämför egenskapsvärden
      for (const compareObj of arrayOfObjects) {
        if (
          compareObj.hasOwnProperty(property) &&
          compareObj[property] === obj[property]
        ) {
          matchingProperties.push(property); // Lägg till matchande egenskap i listan
          break; // Ingen fortsatt jämförelse behövs när en matchning hittas
        }
      }
    }
  }
  // Bestäm om några matchningar hittades
  const hasMatch = matchingProperties.length > 0;

  // Skapa ett anpassat meddelande om en matchning hittades
  const matchingPropertyMessage = hasMatch
    ? `Det finns redan ${
        obj[matchingProperties[0]]
      } i tabellen, var god välj något annat eller avbryt`
    : ""; // Tom sträng om ingen matchning hittades

  // Returnera resultatet som ett objekt
  return {
    hasMatch: hasMatch, // true om det finns matchningar, annars false
    matchingPropertyMessage: matchingPropertyMessage, // Anpassat meddelande vid matchning
  };
}

export function compareObjectPropertiesAfterEdit(
  obj,
  arrayOfObjects,
  excludeProperties = []
) {
  const matchingObjects = []; // Array to store matching objects

  for (const compareObj of arrayOfObjects) {
    // Check if the compareObj has at least one property matching obj
    const hasMatch = Object.keys(obj).some((property) => {
      if (
        obj.hasOwnProperty(property) &&
        !excludeProperties.includes(property) &&
        compareObj.hasOwnProperty(property) &&
        compareObj[property] === obj[property]
      ) {
        return true; // This property has a match
      }
      return false; // No match for this property
    });

    if (hasMatch) {
      matchingObjects.push(compareObj); // Add the matching object to the array
    }
  }

  const totalMatches = matchingObjects.length; // Count of matching objects
  console.log(matchingObjects)

  // Create a custom message based on the matches
  const matchingPropertyMessage =
    totalMatches > 1
      ? `Det finns redan ${totalMatches} matchande objekt i tabellen, var god välj något annat eller avbryt`
      : ""; // Empty string if no matches were found

  // Return the result as an object
  return {
    hasMatch: totalMatches > 1, // true if there are matches, otherwise false
    matchingPropertyMessage: matchingPropertyMessage, // Custom message on match
  };
}

export function updateObjectInArray(array, identifier, updatedObject) {
  // Find the index of the object to update
  const indexToUpdate = array.findIndex(
    (item) => item[identifier] === updatedObject[identifier]
  );

  if (indexToUpdate !== -1) {
    // Update the array with the modified object
    const updatedArray = [...array];
    updatedArray[indexToUpdate] = updatedObject;

    return updatedArray;
  }

  // If the object is not found, return the original array
  return array;
}
