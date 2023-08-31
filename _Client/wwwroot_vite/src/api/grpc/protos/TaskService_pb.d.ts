import * as jspb from 'google-protobuf'

import * as google_protobuf_empty_pb from 'google-protobuf/google/protobuf/empty_pb';


export class TaskResponse extends jspb.Message {
  getGuid(): string;
  setGuid(value: string): TaskResponse;

  getParts(): number;
  setParts(value: number): TaskResponse;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): TaskResponse.AsObject;
  static toObject(includeInstance: boolean, msg: TaskResponse): TaskResponse.AsObject;
  static serializeBinaryToWriter(message: TaskResponse, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): TaskResponse;
  static deserializeBinaryFromReader(message: TaskResponse, reader: jspb.BinaryReader): TaskResponse;
}

export namespace TaskResponse {
  export type AsObject = {
    guid: string,
    parts: number,
  }
}

