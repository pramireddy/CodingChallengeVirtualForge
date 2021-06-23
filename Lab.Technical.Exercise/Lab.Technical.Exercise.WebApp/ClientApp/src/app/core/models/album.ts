export interface IArtist {
    id: number,
    name: string
}

export interface ILabel {
    id: number,
    name: string
}

export interface IStock {
    id: number,
    quantity: number
}

export interface IAlbum {
    id: number;
    name: string;
    artist: IArtist;
    label: ILabel;
    type: string;
    stock: IStock;
}

export interface ICreateAlbumRequest{
    albumName: string;
    artistId: number;
    labelId: number;
    albumType: number;
    stock: number;
}

export interface IAlbumFormOptionsData{
    artists: IArtist[],
    labels: ILabel[]
}

export const AlbumType = new Map<number, string>([
    [111, 'CD'],
    [222, 'Vinyl']
  ]);