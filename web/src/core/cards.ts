export type Tag = {
  guid: string;
  name: string;
};

export type Card = {
  cover: string;
  name: string;
  tags: Tag[];
};

export type Cards = Card[];
